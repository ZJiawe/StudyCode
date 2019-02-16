package Synchronized;

public class Synchoronized implements Runnable{
    //实现买票卖票功能

    //卖票加锁
    String str = new String();   //

    //定义票量总数
    volatile static Integer Total = 100;

    //实现卖票功能
    @Override
    public void run() {
        while (true) {
            synchronized (str) {    //模块上锁同步
                sale();
            }
        }
    }

    //方法上锁同步
    synchronized public void  sale(){
        if (Total > 0) {
            System.out.println(Thread.currentThread().getName() + "买了第" + (100 - Total + 1) + "票" + "还剩余" + (Total-1) + "票");
            Total--;
        } else {
            System.out.println(Thread.currentThread().getName()+"去买票，票卖完了！！！");
            try {
                wait();
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    public static void main(String args[]){
        for (int i = 0; i < 4; i++) {
            Thread test = new Thread(new Synchoronized(),"消费者"+i+"号：");
            //test.setDaemon(true);   //守护线程声明：当main()结束  线程结束
            test.start();
        }
    }
}
