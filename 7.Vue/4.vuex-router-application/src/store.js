import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    List: []
  },
  mutations: {
    commitNews (title, content) {
      this.state.List.push(content)
    }
  },
  actions: {

  }
})
