package impl;

import cn.sxt.dao.datadao;

public class mysqldao implements datadao {
    @Override
    public void getUser() {
        System.out.println("This is Mysql!");
    }
}
