namespace WebApp1.Models
{

    class View1
    {
        //full Implement Property
        private object viewData;

        public object ViewData//box && unboxing
        {
            get { return viewData; }
            set { viewData = value; }
        }

        public dynamic ViewBag{//hide tyoe dedetect runtime
             get { return viewData; }
             set { viewData = value; }
       }

    }

    public class Parent<T>
    {
        public T Model { get; set; }
    }
    public class Child<T> : Parent<T>
    {

    }
    public class Child2 : Parent<int>
    {

    }
    public class Test
    {
        public void testFun()
        {
            View1 v = new View1();
            var c= v.ViewBag + 10;
            Parent<int> obj = new Parent<int>();// Create object from generic class

            
        }
    }

}
