import pojo.Student;
import pojo.Teacher;
import pojo.User;
import org.apache.ibatis.session.SqlSession;
import org.junit.Test;
import service.StudentService;
import service.UserService;
import util.MyBatisUtil;

import java.util.List;

public class test {

    //测试通过id查找
    @Test
    public void SearchById(){
        UserService userService = new UserService();
        User user = userService.getById(6);
        System.out.println(user.toString());
    }

    //新增记录
    @Test
    public void Add(){
        User user = new User();
        user.setName("王五");
        user.setAge(17);
        UserService userService = new UserService();
        userService.addUser(user);
    }

    //删除记录
    @Test
    public void delete(){
        UserService userService = new UserService();
        userService.deleteUser(5);
    }

    //更改记录
    @Test
    public void Update(){
        UserService userService = new UserService();
        User user = userService.getById(6);
        user.setName("赵六");
        userService.updateUser(user);
    }

    //查询所有
    @Test
    public void SelectAll(){
        UserService userService = new UserService();
        List<User> users = userService.selectAllUser();
    }

    //分页查询
    @Test
    public void selectAllUserBySort(){
        UserService userService = new UserService();
        List<User> users = userService.selectAllUserBySort(2,2);
    }

    //使用注解获取所有用户信息  selectAllUserByClass
    @Test
    public void selectAllUserByClass(){
        UserService userService = new UserService();
        List<User> users = userService.selectAllUserByClass();
    }

    //实现多对一连表查询
    @Test
    public void StudentToTeacher(){
        StudentService studentService = new StudentService();
        studentService.serchAllTeacher();
    }

    //实现一对多的连表查询
    @Test
    public void TeacherToStudent(){
        StudentService studentService = new StudentService();
        List<Teacher> teachers =  studentService.serchAllStudent(1);
        for (Teacher t:teachers
             ) {
            System.out.println("Teacher: "+t.getName());
            for (Student s:t.getStudents()
                 ) {
                System.out.println("Student: " + s.getName());
            }
        }
    }

    //实现动态语句查询
    @Test
    public void selectByCondition(){
        UserService userService = new UserService();
        userService.selectByCondition();
    }


}
