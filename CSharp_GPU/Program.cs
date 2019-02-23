using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenCL;

namespace CSharp_GPU
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generate the arrays for the demo
            const int arrayLength = 20;
            int[] a = new int[arrayLength];
            int[] b = new int[arrayLength];
            int[] c = new int[arrayLength]; //this will be the array storing the sum result
            for (int i = 0; i < arrayLength; i++)
            {
                a[i] = i;
                b[i] = i;
            }

            //initialize the OpenCL object
            OpenCL.OpenCL cl = new OpenCL.OpenCL();
            cl.Accelerator = AcceleratorDevice.GPU;

            //Load the kernel from the file into a string
            string kernel = File.ReadAllText("kernel.cl");

            //Specify the kernel code (in our case in the variable kernel) and which function from the kernel file we intend to call
            cl.SetKernel(kernel, "addArray");
            
            //Specify the parameters in the same order as in the function definition
            cl.SetParameter(a, b, c);

            /*
             *Specify the number of worker threads, 
             * in our case the same as the number of elements since every threads processes only one element,
             * and launch the code on the GPU
             */
            cl.Execute(arrayLength);


            Console.WriteLine("Done...");
            for(int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(c[i].ToString()); //print the result on screen
            }
            Console.ReadKey();
        }
    }
}
