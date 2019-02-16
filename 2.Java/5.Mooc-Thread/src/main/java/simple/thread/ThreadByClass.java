package simple.thread;

public class ThreadByClass extends Thread {
     public void run(){
         while(true){
             System.out.println(Thread.currentThread().getName()+"线程。。。");
         }
     }
    public static void main(String[] args) {
        ThreadByClass test1 =new ThreadByClass();
        ThreadByClass test2 =new ThreadByClass();
        test1.setName("线程一");
        test2.setName("线程二");
        test1.start();
        test2.start();
        while(true){
            System.out.println("主线程运行");
        }
    }
}
