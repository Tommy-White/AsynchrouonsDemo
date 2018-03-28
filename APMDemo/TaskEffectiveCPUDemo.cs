using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APMDemo
{
    class TaskEffectiveCPUDemo
    {
        public void SyncPrintString()
        {
            var Hello = SyncGetString();
            var World = SyncGetString(2000);
            Console.WriteLine(Hello + World);
        }

        public void AsyncPrintString()
        {
            var Hello = AsyncGetString();
            var World = SyncGetString(2000);
            Console.WriteLine(Hello.Result +  World);
        }

        /// <summary>
        /// 模拟一个耗时任务
        /// </summary>
        /// <returns></returns>
        private string SyncGetString()
        {
            Thread.Sleep(2000);
            return "Hello";
        }

        /// <summary>
        /// 模拟一个耗时任务
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private string SyncGetString(int count)
        {
            Thread.Sleep(count);
            return "World!";

        }

        private async Task<string> AsyncGetString()
        {
            return await TaskGetString();
        }


        private Task<string> TaskGetString()
        {

            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Hello";
            });
        }
    }
}
