<template>

<div>
  <!--子路由-->
  <ul class="footer">
    <li class="icons">
      <router-link :to="{name : 'childone'}">第一个子页面</router-link>
    </li>
    <li class="icons">
      <router-link :to="{name : 'childtwo'}">第二个子页面</router-link>
    </li>
  </ul>
  <router-view/>
</div>
</template>

<script>
export default {
  name: 'home'
}
</script>

<style scoped lang="scss">
  .footer {
    position: fixed;
    width: 100%;
    height: 60px;
    line-height: 60px;
    left: 0;
    bottom: 0;
    display: flex;
    flex-flow: row nowrap;
    justify-content: space-around;
  }
  .icons{
    list-style: none;
    font-size: 16px;
    flex: 1;
    text-align: center;
    border-top: 1px solid #42b983;
    a {
      color: #42b983;
      display: block;
      &.active {
        color: #fff;
        background: #42b983;
      }
    }
  }
</style>
