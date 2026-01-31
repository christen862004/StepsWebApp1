namespace WebApp1.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {
            //sort using Buuble Sort alg
        }
    }
    class SelectionSort:ISort
    {
        public void Sort(int[] arr) { }
    }

    class ChrisSort : ISort
    {
        public void Sort(int[] arr) { }

    }
    class MyList
    {
        int[] arr;
        ISort SortAl;//lossly  couple
        public MyList(ISort s)//DI ask consutor
        {
            arr = new int[10];
            SortAl = s;// new BubbleSort();
        }
        public void SortList()// (ISort s)//method
        {
            SortAl.Sort(arr);
        }
    }
    class test
    {
        public void xyz()
        {




            MyList l1 = new MyList( new BubbleSort());//Contoller Factory
            MyList l2 = new MyList(new SelectionSort());
            MyList l3 = new MyList(new ChrisSort());
            l1.SortList();//sort using Bubblesort
            l2.SortList();//sort using Bubblesort
        }
    }














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
