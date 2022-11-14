using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace double_linked_list
{
    class node
    {
        /*Node class represent the node of doubly linked list.
         * it consist of the information part and links to
         * its succeding and precceding
         * in terms of the next*/
        public int noMhs;
        public string name;
        //point to succeding
        public node next;
        //point to precceding
        public node prev;

    }
    class DoubleLinkedList
    {
        node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addnode()
        {
            int nim;
            string nm;
            Console.Write("\nEnter the roll number of the student: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            node newNode = new node();
            newNode.noMhs = nim;
            newNode.name = nm;

            if (START == null || nim <= START.noMhs)
            {
                if ((START != null) && (nim == START.noMhs))
                {
                    Console.WriteLine("\nDuplicate number not allowed");
                    return;
                }
                newNode.next = START;
                if (START != null)
                    START.prev = null;
                START = newNode;
                return;
            }
            node previous, current;
            for (current = previous =START; current != null && nim >= current.noMhs; previous = current, current = current.next)
            {
                if (nim == current.noMhs)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed");
                    return ;
                }
            }
            newNode.next = current;
            newNode.prev = previous;

            if (current == null)
            {
                newNode.next = null;
                previous.next = newNode;
                return ;
            }
            current.prev = newNode;
            previous.next = newNode;

        }
        public bool search(int rollNo, ref node previous, ref node current)
        {
            for (previous = current = START; current != null && rollNo != current.noMhs; previous = current, current = current.next) { }
            return (current != null);
        }
        public bool dellNode(int rollNo)
        {
            node previous, current;
            previous = current = null;
            if (search(rollNo, ref previous, ref current) == false)
                return false;
            if (current.next == null)
            {
                previous.next = null ;
                return true;
            }
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null ;
                return true;
            }
            previous.next = current.next;
            current.next.prev = current;
            return true;
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void ascending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the ascending order of" + "roll number are:\n");
                node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.noMhs + "" + currentNode.name + "\n");
            }
        }
        public void descending()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecord in the Descending order of" + "roll number are:\n");
                node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next) { }

                while(currentNode != null)
                {
                    Console.WriteLine(currentNode.noMhs + "" + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
    }
}