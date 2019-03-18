<template>
<div>
  Hello, I'm Test
  <button @click="add()">点击输出日志</button>
</div>
</template>

<script>
import store from '@/store'
export default {
  name: 'Test',
  methods: {
    add () {
      // console.log('running')
      // debugge
      // console.error('error')
      // alert('Test')
      store.commit('increase')
    }
  },
  // 组建加载完后加载mounted
  mounted () {
    window.vue = this
  }
}
</script>

<style scoped>

</style>
