using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCL;

namespace CSharp_GPU
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize the OpenCL object
            OpenCL.OpenCL cl = new OpenCL.OpenCL();
            cl.Accelerator = AcceleratorDevice.GPU;

            //Load the kernel
        }
    }
}
