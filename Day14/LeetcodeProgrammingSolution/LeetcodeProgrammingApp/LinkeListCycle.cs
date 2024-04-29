using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeProgrammingApp
{
      public class ListNode
    {
      public int val;
      public ListNode next;
     public ListNode(int x)
        {
            val = x;
           next = null;
                 }
  }

    

    public class LinkeListCycle
    {
        public ListNode head, tail;

        public LinkeListCycle()
        {
            head = null;
            tail = null;
        }

        public async Task<bool> CheckCollision(ListNode single, ListNode twice)
        {


            if (single == null || twice == null || twice.next == null)
            {
                return false;
            }

            if (single == twice)
            {
                return true;
            }

            return await CheckCollision(single.next, twice.next.next);


        }

        public async Task<bool> HasCycle(ListNode head)
        {

            ListNode single = head;
            ListNode twice = head;
            if (single == null)
            {
                return false;
            }
            if (single.next == null)
            {
                return false;
            }
            return await CheckCollision(single.next, twice.next.next);
        }


        public void AddNode( int value)
        {
            ListNode node = new ListNode(value);

            if(head== null && tail==null)
            {
                head = new ListNode(value) ;
                tail = head;
            }
            else {

                tail.next = new ListNode(value);
                tail = tail.next;
                
            }
            


        }
        public bool GetNum(int input, out int result)
        {
            result = 0;
            if (input == 0)
            {
                return false;
            }
            result = input;
            return true;
        }

        public async void HasCycle()
        {

           
            int value;
            Console.WriteLine("Enter the values\nEnter 0 to quit");
            while(GetNum(Convert.ToInt32(Console.ReadLine()),out value))
            {
                AddNode(value);
            }

            tail.next = head;

            if ( await CheckCollision(head.next, head.next.next))
            {
                Console.WriteLine("The cycle is present");
            }
            else
            {
                Console.WriteLine("There is no cycle");
            }


        }

        static void Main(string[] args)
        {

            LinkeListCycle linkeListCycle = new LinkeListCycle();
            linkeListCycle.HasCycle();

        }


    }
}
