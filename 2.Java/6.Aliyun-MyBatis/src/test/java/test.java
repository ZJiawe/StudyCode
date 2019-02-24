import pojo.User;
import org.apache.ibatis.session.SqlSession;
import org.junit.Test;

public class test {

    @Test
    public void Test(){
        SqlSession session = MyBatisUtil.getSession();
        try {
            User users = (User) session.selectOne("getById","1");
            System.out.println(users.getClass()+":"+"name="+users.getName()+",age="+users.getAge());
        } finally {
            session.close();
        }
    }

}
