*IMPORTANT 
{
	The packages folder is deleted. You may need to create a new ASP.NET MVC project and replace all but the packages folder in case NuGetPackages don't recover as they should. The project as is is 27MB of size and I can't really upload it ;/
}

I completed all ot the following tasks in this single and first for me ASP.NET MVC Application.

TASKS:

1.Write down in a text file all the major similarities and differences you can find between ASP.NET Web Forms and ASP.NET MVC

2.Using ASP.NET MVC write the same web calculator as: http://www.gwebtools.com/bit-calculator

3.Create a simple informational ASP.NET MVC application by your choice with at least 3 controllers, 1 area, 1 custom route, 5 views (at least 1 partial view and 1 section). Using data is not required.

	Custom Route: /very/super/cool/secret/route/{color}
	(where you can specify the background color)

	Partial View: The table of convertions at /Calculator

	Section: The rainbow footer at /RainbowUnicorns/Magical/ActivateSpecialPower

4.* Create a custom route constraint that allows requests only if the controller name starts with the string "Admin"
	For AdminPanel/{controller}/{action}/{id}

	/Admin route will only work for such controllers. Try sending /Admin to another controller and you will
	see in Glimpse it will be using another route 


