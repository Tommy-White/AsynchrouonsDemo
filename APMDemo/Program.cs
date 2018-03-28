using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APMDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            /*****************************Debug*****************************/

            //Console.WriteLine("主线程开始！");

            ////创建前台工作线程
            ////Thread t1 = new Thread(Task1);
            //Thread t1 = new Thread(() =>
            //{
            //    Thread.Sleep(1000);
            //    Console.WriteLine("前台线程被调用！");
            //});
            //t1.Start();

            ////创建后台工作线程
            //Thread t2 = new Thread(new ParameterizedThreadStart(Task2));
            //t2.IsBackground = true;//设置为后台线程
            //t2.Start("传参");

            /*****************************Debug*****************************/

            //Console.WriteLine("主线程开始！");
            ////创建要执行的任务
            //WaitCallback workItem = state => Console.WriteLine("当前线程Id为：" + Thread.CurrentThread.ManagedThreadId);

            ////重复调用10次
            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(workItem);
            //}
            //Console.ReadLine();

            /*****************************Debug*****************************/

            //ParallelLoopResult result = Parallel.For(0, 100, i =>
            //{
            //    Console.WriteLine("{0}, task: {1} , thread: {2}", i, Task.CurrentId, Thread.CurrentThread.ManagedThreadId);
            //});
            //Console.WriteLine("result.IsCompleted:" + result.IsCompleted );
            //Console.ReadKey();

            /*****************************Debug*****************************/

            //Console.WriteLine("主线程ID：" + Thread.CurrentThread.ManagedThreadId);
            //Task.Factory.StartNew(() => Console.WriteLine("Task对应线程ID：" + Thread.CurrentThread.ManagedThreadId));
            //Task.Run(() => Console.WriteLine("Task对应线程ID：" + Thread.CurrentThread.ManagedThreadId));  //.Net 4.5
            //Console.WriteLine("主线程回归");
            //Console.ReadLine();

            /*****************************Debug*****************************/

            //C# async关键字用来指定某个方法、Lambda表达式或匿名方法自动以异步的方式来调用。
            //Console.WriteLine("主线程启动，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
            //var task = GetLengthAsync();

            //Console.WriteLine("回到主线程，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            ////Console.WriteLine("线程[" + Thread.CurrentThread.ManagedThreadId + "]睡眠5s:");
            ////Thread.Sleep(5000); //将主线程睡眠5s

            //var timer = new Stopwatch();
            //timer.Start(); //开始计算时间

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("task的返回值是" + task.Result);

            //timer.Stop(); //结束点，另外stopwatch还有Reset方法，可以重置。
            //Console.WriteLine("等待了：" + timer.Elapsed.TotalSeconds + "秒"); //显示时间

            //Console.WriteLine("主线程结束，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            //Console.ReadKey();

            /*****************************Debug*****************************/

            var task = new TaskEffectiveCPUDemo();
            var timer = new Stopwatch();

            timer.Start();
            task.SyncPrintString();
            Console.WriteLine("Sync执行了：{0}s", timer.Elapsed.TotalSeconds);

            timer.Restart();
            task.AsyncPrintString();
            Console.WriteLine("Async执行了：{0}s", timer.Elapsed.TotalSeconds);

            /*****************************Debug*****************************/
        }

        private static void Task1()
        {
            Thread.Sleep(1000);//模拟耗时操作，睡眠1s
            Console.WriteLine("前台线程被调用！");
        }

        private static void Task2(object data)
        {
            Thread.Sleep(1000);//模拟耗时操作，睡眠2s
            Console.WriteLine("后台线程被调用！" + data);
        }

        private static async Task<int> GetLengthAsync()
        {
            Console.WriteLine("GetLengthAsync()开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            var str = await GetStringAsync();

            Console.WriteLine("GetLengthAsync()执行完毕，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            return str.Length;
        }

        private static Task<string> GetStringAsync()
        {
            Console.WriteLine("GetStringAsync()开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
                Console.WriteLine("GetStringAsync()开始执行，目前还是同步任务，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

            return Task.Run(() =>
            {
                Console.WriteLine("异步任务开始执行，当前线程为：" + Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine("线程[" + Thread.CurrentThread.ManagedThreadId + "]睡眠10s:");
                Thread.Sleep(10000); //将异步任务线程睡眠10s

                Console.WriteLine("GetStringAsync()执行完毕，当前线程为：" + Thread.CurrentThread.ManagedThreadId);
                return "GetStringAsync()执行完毕";
            });
        }

    }
}
