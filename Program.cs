// See https://aka.ms/new-console-template for more information
using LMS.UI;
namespace Program
{
    class Program
    {
        static void Main(string[] argvs)
        {
            MenuManager menuManager = new MenuManager();
            while (true)
            {
                try{
                    menuManager.ShowMenu();
                    int choice = menuManager.GetChoice();
                    menuManager.RunOperation(choice);
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
