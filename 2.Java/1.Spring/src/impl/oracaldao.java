package impl;

import cn.sxt.dao.datadao;

public class oracaldao implements datadao {
    @Override
    public void getUser() {
        System.out.println("This is oracal!");
    }
}
