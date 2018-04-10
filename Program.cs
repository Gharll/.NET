using studia_dn.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace studia_dn
{
    class Program
    {
        static void createTestTools(ToolBox tb)
        {
            ToolFactory tf = new ToolFactory();

            var ma1 = tf.CreateAirplane("myAirplane1");
            ma1.Age = 2;
            ma1.BaseWorth = new Worth(5, 10);
            tb.AddTool(ma1);
            ma1.Birthday();

            var mb1 = tf.CreateBike("myBike");
            mb1.Age = 6;
            mb1.BaseWorth = new Worth(60, 30);
            tb.AddTool(mb1);

            var ms1 = tf.CreateSubmarine("mySubmarine");
            ms1.Age = 9;
            ms1.BaseWorth = new Worth(30, 20);
            tb.AddTool(ms1);

            tb.DeleteTool(ms1);

            tb.ChangeAccelarate(100);
        }

        static void printTools(ToolBox tb)
        {
            foreach (var tool in tb.GetRiseTools())
            {
                Console.WriteLine(tool.ToString());
            }
            Console.WriteLine("\n");

            foreach (var tool in tb.GetAccelarateTools())
            {
                Console.WriteLine(tool.ToString());
            }

            Console.WriteLine("\n");

            foreach (var tool in tb.GetDiveTools())
            {
                Console.WriteLine(tool.ToString());
            }

            Console.WriteLine("\n");
        }

        static void showToolsWorth(ToolBox tb)
        {
            foreach(var tool in tb.tools)
            {
                Console.WriteLine("Tool name: " + tool.Name);
                Console.WriteLine("Age: " + tool.Age);
                Console.WriteLine("Base worth: " + tool.BaseWorth);
                Console.WriteLine("Current worth: " + tool.CurrentWorth + "\n");
            }
        }


        static int SleepTime = 0;
        static ToolBox tb = new ToolBox();
        static ToolFactory tf = new ToolFactory();
        static Mutex mutex = new Mutex();

        static void AddThreadHandle()
        {
            Random rnd = new Random();
            while (true)
            {
                mutex.WaitOne();
                int toolNumber = rnd.Next(1, 4);
                Tool tool = null;
                switch (toolNumber)
                {
                    case 1:
                        tool = tf.CreateAirplane("Thread Airplane");
                        break;
                    case 2:
                        tool = tf.CreateBike("Thread Bike");
                        break;
                    case 3:
                        tool = tf.CreateSubmarine("Threa Submarine");
                        break;
                }
                tb.AddTool(tool);
                Console.WriteLine("Created tool: " + tool.Name);

                mutex.ReleaseMutex();
                System.Threading.Thread.Sleep(SleepTime);

                
                
            }
        }

        static void EditParameterThreadHandle()
        {
            Random rnd = new Random();
            while (true)
            {
                mutex.WaitOne();
                int toolBoxSize = tb.tools.Count;
                if(toolBoxSize > 0)
                {
                    Tool tool = tb.tools[rnd.Next(0, toolBoxSize-1)];
                    
                    if(tool.GetType() == typeof(Airplane))
                    {
                        Airplane plane = (Airplane)tool;
                        plane.ChangeAccelarate(plane.accelarate + rnd.Next(-10, 11));
                    }
                    if (tool.GetType() == typeof(Bike))
                    {
                        Bike bike = (Bike)tool;
                        bike.ChangeAccelarate(bike.accelarate + rnd.Next(-10, 11));
                    }
                    if (tool.GetType() == typeof(Submarine))
                    {
                        Submarine submarine = (Submarine)tool;
                        submarine.ChangeDive(submarine.dive + rnd.Next(-10, 11));
                    }
                    Console.WriteLine("The tool: " + tool.Name + "has changed the attribute");
                }
                mutex.ReleaseMutex();
                System.Threading.Thread.Sleep(SleepTime);
            }

               
                
            }
        
        
        static void deleteThreadHandle()
        {
            Random rnd = new Random();
            while (true)
            {
                mutex.WaitOne();
                int toolBoxSize = tb.tools.Count;
                if(toolBoxSize > 0)
                {
                    Tool tool = tb.tools[rnd.Next(0, toolBoxSize-1)];
                    Console.WriteLine(toolBoxSize);
                    Console.WriteLine("Removed tool " + tool.Name + " from toolbox");
                    tb.tools.Remove(tool);
                   
                }

               

                mutex.ReleaseMutex();
                System.Threading.Thread.Sleep(SleepTime);
            }
        }

        static void Main(string[] args)
        {
            ToolBox tb = new ToolBox();
            createTestTools(tb);
            printTools(tb);
            showToolsWorth(tb);
            Console.ReadKey();
            Console.WriteLine("=======\n\n");
            Console.WriteLine("Threads started!");
            var addThread1 = new Thread(AddThreadHandle);
            var addThread2 = new Thread(AddThreadHandle);
            var addThread3 = new Thread(AddThreadHandle);
            addThread1.Start();
            addThread2.Start();
            addThread3.Start();

            var deleteThread1 = new Thread(deleteThreadHandle);
            var deleteThread2 = new Thread(deleteThreadHandle);
            var deleteThread3 = new Thread(deleteThreadHandle);
            deleteThread1.Start();
            deleteThread2.Start();
            deleteThread3.Start();

            var chageThread1 = new Thread(EditParameterThreadHandle);
            var chageThread2 = new Thread(EditParameterThreadHandle);
            var chageThread3 = new Thread(EditParameterThreadHandle);

            chageThread1.Start();
            chageThread2.Start();
            chageThread3.Start();

            Console.ReadKey();
            
        }
    }
}
