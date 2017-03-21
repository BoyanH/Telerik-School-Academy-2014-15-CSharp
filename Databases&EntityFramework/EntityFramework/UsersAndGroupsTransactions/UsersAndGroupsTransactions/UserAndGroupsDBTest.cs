using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Transactions;
using System.Linq;

namespace UsersAndGroupsTransactions
{
    public class UserAndGroupsDBTest
    {

        public static int CreateUserAndPutInGroupAdmins(string firstName, string lastName, short age)
        {
            int affectedRows = 0;

            using (var db = new UsersAndGroupsEntities())
            {
                using (var scope = new TransactionScope())
                {


                    var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                    var userGroup = db.Groups.FirstOrDefault(group => group.Name == "Admins");

                    if (userGroup == null)
                    {
                        userGroup = db.Groups.Add(new Group()
                        {
                            Name = "Admins"
                        }
                        );
                    }

                    var newUser = new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age
                    };

                    newUser.UserGroups.Add(new UserGroup() { Group = userGroup });

                    db.Users.Add(newUser);

                    affectedRows = objectContext.SaveChanges(false);

                    //if we get everything is executed fine, no rollback.
                    //  else => no AcceptAllChanges() called, which is same as Rollback (I suppose)
                    scope.Complete();
                    objectContext.AcceptAllChanges();
                }
            }

            return affectedRows;
        }

        public static void Main()
        {
            try
            {
                CreateUserAndPutInGroupAdmins("Boyan", "Hristov", 18);
            }
            catch (Exception ex)
            {
                Console.WriteLine("User already exists ;)");
            }

            using (var db = new UsersAndGroupsEntities())
            {
                Console.WriteLine("User belongs to group: {0}",
                    db.Users.FirstOrDefault(user => user.FirstName == "Boyan").UserGroups.FirstOrDefault().Group.Name);
            }
        }
    }
}
