<template>
  <div class="about">
    <h1>This is an about page</h1>
    <h1>{{msg}}</h1>
  </div>
</template>

<script>
import store from '@/store'
export default {
  store,
  data () {
    return {
      msg: store.state.count
    }
  }
}
</script>
