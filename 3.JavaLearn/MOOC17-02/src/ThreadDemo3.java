public class ThreadDemo3
{
	public static void main(String args[])
	{
		//new TestThread3().start();
		//Runnable����������һ��Thread���в�������
		TestThread3 tt= new TestThread3();//����TestThread���һ��ʵ��
		Thread t= new Thread(tt);//����һ��Thread���ʵ��
		t.start();//ʹ�߳̽���Runnable״̬
		while(true)
		{
			System.out.println("main thread is running");
			try {
				Thread.sleep(1000); //1000����
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
class TestThread3 implements Runnable //extends Thread
{
	//�̵߳Ĵ���Σ���ִ��start()ʱ���̴߳Ӵ˳���ʼִ��
	public void run()
	{
		while(true)
		{
			System.out.println(Thread.currentThread().getName() +
			" is running");
			try {
				Thread.sleep(1000); //1000����
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}
}
