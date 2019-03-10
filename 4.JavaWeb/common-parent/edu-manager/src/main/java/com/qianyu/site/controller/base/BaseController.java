package com.qianyu.site.controller.base;

import java.lang.reflect.ParameterizedType;

public abstract class BaseController<T> {
    protected final String LOGIN = "login";
    protected final String FIND = "find";
    protected final String MANAGE = "manage";
    protected final String INFO = "info";
    protected final String EDIT = "edit";
    protected static String MODELNAME;
    protected static String PAGE_MANAGE ;
    protected static String PAGE_INFO ;
    protected static String PAGE_EDIT ;

    public BaseController() {
        //    1.获取泛型的真实类型
        ParameterizedType type = (ParameterizedType) this.getClass().getGenericSuperclass();
        System.out.println("=================="+type.toString());
        Class<?> modelClass = (Class<?>) type.getActualTypeArguments()[0];
        System.out.println("=================="+modelClass.toString());
        //    2.获取模块名
        MODELNAME = modelClass.getSimpleName().toLowerCase();
        System.out.println(MODELNAME);

        //    3.赋值给属性
        PAGE_MANAGE = MODELNAME + "/" + MANAGE.substring(0,1).toUpperCase()+MANAGE.substring(1).toLowerCase();
        PAGE_INFO = MODELNAME + "/" + INFO.substring(0,1).toUpperCase()+INFO.substring(1).toLowerCase();
        PAGE_EDIT = MODELNAME + "/" + EDIT.substring(0,1).toUpperCase()+EDIT.substring(1).toLowerCase();
    }
}
