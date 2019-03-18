import Vue from 'vue'
import Router from 'vue-router'
import New from './views/New.vue'
import Home from './views/Home'
import Login from './views/Login'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  // 激活触发active样式类
  linkActiveClass: 'active',
  routes: [
    {
      path: '/',
      name: 'login',
      component: Login
    },
    {
      path: '/Home',
      name: 'home',
      component: Home,
      children: [
        {
          path: '/childone',
          name: 'childone',
          component: () => import('./views/HomeChildOne.vue')
        },
        {
          path: '/childtwo',
          name: 'childtwo',
          component: () => import('./views/HomeChildTwo.vue')
        }
      ]
    },
    {
      path: '/List',
      name: 'list',
      component: () => import('./views/List.vue')
    },
    {
      path: '/New',
      name: 'news',
      component: New
    }
  ]
})
