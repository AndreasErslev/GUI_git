<template>
  <div id="nav">
    <router-link to="/">Home | </router-link>
    <!--<router-link to="/about">About</router-link> |-->
    <router-link to="/CreateManager" v-if="role == 'Manager'"
      >Create new manager |
    </router-link>
    <router-link to="/CreateModel" v-if="role == 'Manager'"
      >Create new model |
    </router-link>
    <router-link to="/Login" v-if="role == ''">Login | </router-link>
    <router-link to="/AddJob" v-if="role == 'Manager'">Add Job | </router-link>
    <router-link to="/JobsManager" v-if="role == 'Manager'"
      >Jobs |
    </router-link>
    <router-link to="/JobsModel" v-if="role == 'Model'">Jobs | </router-link>
    <router-link to="/Expenses" v-if="role == 'Model'">Expenses | </router-link>
    <a href="#" v-if="role != ''" v-on:click="logout()">Logout</a>
  </div>
  <router-view />
</template>

<script>
export default {
  data() {
    return {
      role: "",
    };
  },
  mounted() {
    this.role = localStorage.getItem("role");
  },
  methods: {
    logout() {
      // fjerner token, email og rolle, samt g�r til login siden
      localStorage.setItem("token", "");
      localStorage.setItem("email", "");
      localStorage.setItem("role", "");
      localStorage.setItem("modelId", "");
      this.$router.push("/Login");
    },
  },
  watch: {
    $route() {
      // Hver gang man skrifter route hentes rollen
      this.role = localStorage.getItem("role");
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
