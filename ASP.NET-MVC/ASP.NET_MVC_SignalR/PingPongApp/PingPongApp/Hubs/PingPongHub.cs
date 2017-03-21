namespace PingPongApp.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.SignalR;
    using System.Threading.Tasks;
    using System.Web.Routing;

    public static class GroupCounter
    {
        public static Dictionary<string, int> ExistingGroups = new Dictionary<string, int>();
    }

    public class PingPongHub : Hub
    {

        public void Join(string roomName)
        {
            if (!GroupCounter.ExistingGroups.ContainsKey(roomName))
            {
                Groups.Add(Context.ConnectionId, roomName);
                
                GroupCounter.ExistingGroups.Add(roomName, 1);

                Clients.Caller.joinedGroup();
            }
            else if (GroupCounter.ExistingGroups[roomName] == 1)
            {
                    
                GroupCounter.ExistingGroups[roomName] = 2;
                Groups.Add(Context.ConnectionId, roomName);

                Clients.Caller.joinedGroup();

                Clients.Group(roomName).startGame();
            }
            else
            {
                Clients.Caller.groupNotAvailable();
            }
        }

        public void UpdateGameStats(string paddleDir, string ballX, string ballY, string ballXDir, string ballYDir, string roomName)
        {

            ballXDir = ballXDir == "left" ? "right" : "left";
            ballYDir = ballYDir == "down" ? "up" : "down";

            Clients.AllExcept(Clients.Caller).Group(roomName).updateClientStats(paddleDir, ballXDir, ballYDir, ballX, ballY);
        }

        public Task Disconnect(string roomName)
        {
            return Groups.Remove(Context.ConnectionId, roomName);
        }
    }
}