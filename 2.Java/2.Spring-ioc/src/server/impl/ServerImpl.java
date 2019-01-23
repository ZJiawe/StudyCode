package server.impl;

import cn.sxt.dao.datadao;
import server.service;

public class ServerImpl implements service {
    private datadao data = null;
    public void setData(datadao data) {
        this.data = data;
    }
    public void getData(){
        data.getUser();
    }
}
