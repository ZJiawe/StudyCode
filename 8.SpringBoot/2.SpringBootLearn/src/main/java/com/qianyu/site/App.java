package com.qianyu.site;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;

@EnableAutoConfiguration
@ComponentScan(basePackages = "com.qianyu.site")
//@ComponentScan(basePackages = {"com.qianyu.site.controller","packet2"})   扫描多个包
public class App
{
    public static void main( String[] args )
    {
        SpringApplication.run(App.class,args);
    }
}
