<template>
  <div>
    <ui>
      <li v-for="(item,index) in List"
          :key="index"
          :class="{change : current == index}"
          @click="changBackGround(index)">
          {{item}}
      </li>
    </ui>
  </div>

</template>

<script>
export default {
  name: 'Demo1',
  data () {
    return {
      List: [9, 8, 7, 6, 5],
      current: ''
    }
  },
  methods: {
    changBackGround (index) {
      this.current = index
    }
  }
}
</script>

<style scoped lang="scss">
  .change {
    background: aqua;
    color: blueviolet;
  }
</style>
