package com.qianyu.site;

import org.mybatis.spring.annotation.MapperScan;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.EnableAutoConfiguration;
import org.springframework.context.annotation.ComponentScan;

@EnableAutoConfiguration
@MapperScan(basePackages = "com.qianyu.site.mapper")
@ComponentScan(basePackages = {"com.qianyu.site.aop","com.qianyu.site.controller","com.qianyu.site.service","com.qianyu.site.exception"})
//@ComponentScan(basePackages = {"com.qianyu.site.controller","packet2"})   扫描多个包
public class App
{
    public static void main( String[] args )
    {
        SpringApplication.run(App.class,args);
    }
}
