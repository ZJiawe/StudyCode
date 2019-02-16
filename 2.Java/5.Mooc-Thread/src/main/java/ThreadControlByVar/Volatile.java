package ThreadControlByVar;

public class Volatile implements Runnable{
    public void setFlag(Boolean flag) {
        this.flag = flag;
    }

    volatile Boolean flag = true;

    @Override
    public void run() {
        while (flag) {
            System.out.println(Thread.currentThread().getName() + "正在执行中。。");
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }



    public static void main(String args[]){
        Volatile vola = new Volatile();
        Thread test1 = new Thread(vola,"Thread 1:");
        Thread test2 = new Thread(new Volatile(),"Thread 2:");
        test1.start();
        test2.start();
        vola.setFlag(false);     //设定值终止线程
        System.out.println(test1.getClass());
    }
}
