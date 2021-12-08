<template>
    <div id="app" class="w-100 h-100">
        <navbar></navbar>
        <router-view class="container custom-margin" />
    </div>
</template>

<script>
import Navbar from "@/components/Navbar";
export default {
    components: {
        Navbar,
    },
};
</script>

<style>
.custom-margin {
    padding-top: 56px;
}
#app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
}

#nav a.router-link-exact-active {
    color: #42b983;
}

html,
body {
    height: 100%;
    padding: 0;
    margin: 0;
    background-color: #ecf0f1 !important;
}
</style>
