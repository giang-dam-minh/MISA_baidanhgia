const state = {
    role: 1
  }
  
  const mutations = {
    TOGGLE_ROLE: (state,val) => {
        state.role = val
    },
  }
  
  const actions = {
    toggleRole({ commit }, val) {
      commit('TOGGLE_ROLE',val)
    },
  }
  
  export default {
    namespaced: true,
    state,
    mutations,
    actions
  }