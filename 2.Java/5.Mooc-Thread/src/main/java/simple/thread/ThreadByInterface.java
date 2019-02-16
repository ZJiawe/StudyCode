package simple.thread;

public class ThreadByInterface implements Runnable {
    @Override
    public void run() {
        while(true){
            System.out.println(Thread.currentThread().getName()+"线程。。。");
        }
    }

    public static void main(String[] args) {
        Thread test1 = new Thread(new ThreadByInterface(),"线程一：");
        Thread test2 = new Thread(new ThreadByInterface(),"线程二：");
        test1.start();
        test2.start();
        while(true){
            System.out.println(Thread.currentThread().getName()+"主线程");
        }
    }
}
