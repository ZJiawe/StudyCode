package service;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import pojo.ISearch;
import pojo.Student;
import util.MyBatisUtil;

import java.util.List;

public class StudentService implements ISearch {
    //寻找学生所对应的老师
    public void serchAllTeacher() {
        SqlSession sesson = MyBatisUtil.getSession();
        List<Student> students = sesson.selectList("serchAllTeacher");
        for (Student student:students
             ) {
            System.out.println(student.toString());
        }
    }
}
