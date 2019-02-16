public class ThreadDemo3
{
	public static void main(String args[])
	{
		//new TestThread3().start();
		//Runnable对象必须放在一个Thread类中才能运行
		TestThread3 tt= new TestThread3();//创建TestThread类的一个实例
		Thread t= new Thread(tt);//创建一个Thread类的实例
		t.start();//使线程进入Runnable状态
		while(true)
		{
			System.out.println("main thread is running");
			try {
				Thread.sleep(1000); //1000毫秒
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
class TestThread3 implements Runnable //extends Thread
{
	//线程的代码段，当执行start()时，线程从此出开始执行
	public void run()
	{
		while(true)
		{
			System.out.println(Thread.currentThread().getName() +
			" is running");
			try {
				Thread.sleep(1000); //1000毫秒
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
