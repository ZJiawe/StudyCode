package com.qianyu.site.exception;

import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.HashMap;
import java.util.Map;

@ControllerAdvice  //控制器切面
public class GlobalExceptionHandler {
    // 处理异常方法
    @ExceptionHandler(RuntimeException.class)
    @ResponseBody  //返回Json
    public Map<String, Object> runException(){
        Map<String, Object> map = new HashMap<String, Object>();
        map.put("errorCode","101");
        map.put("errorMsg","系统错误！");
        return map;
    }
}
