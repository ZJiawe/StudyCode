package test;

import org.springframework.context.ApplicationContext;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import server.impl.ServerImpl;

public class test2 {
    public static void main(String[] args){
        ApplicationContext ac = new ClassPathXmlApplicationContext("spring.xml");
        ServerImpl server =(ServerImpl)ac.getBean("service");
        server.getData();
    }
}
