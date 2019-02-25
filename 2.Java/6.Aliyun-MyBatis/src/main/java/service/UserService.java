package service;

import org.apache.ibatis.session.SqlSession;
import pojo.IUser;
import pojo.User;
import util.MyBatisUtil;

import java.util.List;

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
}
