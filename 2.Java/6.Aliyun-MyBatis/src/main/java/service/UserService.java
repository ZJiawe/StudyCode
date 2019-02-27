package service;

import org.apache.ibatis.session.RowBounds;
import org.apache.ibatis.session.SqlSession;
import pojo.IUser;
import pojo.IUserTest;
import pojo.User;
import util.MyBatisUtil;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class UserService implements IUser {

    //主键查找
    public User getById(int id) {
        SqlSession session = MyBatisUtil.getSession();
        User user = (User) session.selectOne("getById",id);
        session.close();
        return user;
    }

    //新增记录
    public void addUser(User user) {
        SqlSession session = MyBatisUtil.getSession();
        try {
            System.out.println(user.toString());
            session.insert("addUser",user);
            session.commit();
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
    }

    //通过主键删除某条记录
    public void deleteUser(int id) {
        SqlSession session = MyBatisUtil.getSession();
        try {
            session.delete("deleteUser",id);
            session.commit();
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
    }

    //更新记录
    public void updateUser(User user) {
        SqlSession session = MyBatisUtil.getSession();
        try {
            session.update("updateUser",user);
            session.commit();
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
    }

    //查询所有
    public List<User> selectAllUser() {
        List<User> users;
        SqlSession session = MyBatisUtil.getSession();
        try {
            users = session.selectList("selectAllUser");
            for (int i = 0; i < users.size() ; i++) {
                System.out.println(users.get(i).toString());
            }
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
        return users;
    }

    //实现分页查询
    public List<User> selectAllUserBySort(Integer startIndex,Integer pageNum) {
        List<User> users;
        SqlSession session = MyBatisUtil.getSession();

        //方法一map实现分页
        /*
        Map<String,Integer> map = new HashMap<String, Integer>();
        map.put("startIndex",(startIndex-1)*pageNum);
        map.put("pageNum",pageNum);
        try {
            users = session.selectList("selectAllUserBySort",map);
            for (int i = 0; i < users.size() ; i++) {
                System.out.println(users.get(i).toString());
            }
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
        */

        //方法二mybatis自带分页功能
        RowBounds rowBounds = new RowBounds((startIndex-1)*pageNum,pageNum);
        try {
            users = session.selectList("selectAllUser",null,rowBounds);
            for (int i = 0; i < users.size() ; i++) {
                System.out.println(users.get(i).toString());
            }
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }

        //返回值
        return users;
    }

    //实现查询   通过辅助注解实现
    public List<User> selectAllUserByClass() {
        List<User> users;
        SqlSession session = MyBatisUtil.getSession();

        //获取通过接口获取实现类
        IUserTest iUserTest = session.getMapper(IUserTest.class);

        try {
            //直接调用实现类的方法即可
            users = iUserTest.selectAllUser();
            for (int i = 0; i < users.size() ; i++) {
                System.out.println(users.get(i).toString());
            }
        } finally {
            session.close();
            System.out.println("执行成功。。。");
        }
        return users;
    }

    //实现动态sql语句查询
    public List<User> selectByCondition() {
        SqlSession session = MyBatisUtil.getSession();
        Map<String,String> map = new HashMap<String, String>();
        map.put("name","郑");
        List<User> users = session.selectList("selectByCondition",map);
        for (User u:users
             ) {
            System.out.println(u.toString());
        }
        return null;
    }
}
