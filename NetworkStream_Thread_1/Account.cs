using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStream_Thread_1
{
    //server account class
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Sum { get; set; }
        public int Procent { get; set; }
        public Account(string userName,decimal sum,int period)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = userName;
            this.Sum = sum;
            this.Procent = period > 12 ? 10 : 1; 
        }
    }
}
