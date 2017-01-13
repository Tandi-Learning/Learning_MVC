using ClassLibrary2;
using Ninject;
using Ninject.Modules;
using System;

namespace ClassLibrary1
{
    public class Class1Module : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IClass2)).To(typeof(Class2)).InSingletonScope();
        }
    }

    public class Class1Service
    {
        private IClass2 _class2;
        public Class1Service(IClass2 class2)
        {
            _class2 = class2;
        }

        public string GetName()
        {
            return _class2.GetName();
        }
    }

    public class Class1Operation
    {
        Class1Service class1Service;
        public Class1Operation(IKernel kernel)
        {
            class1Service = kernel.Get<Class1Service>();
        }

        public string GetName()
        {
            return class1Service.GetName();
        }
    }

    public class Class1
    {
        public Class1()
        {
            IKernel kernel = new StandardKernel(new Class1Module());
            Class1Operation class1Operation = new Class1Operation(kernel);
            Console.WriteLine(class1Operation.GetName());
            Console.ReadLine();
        }
    }
}
