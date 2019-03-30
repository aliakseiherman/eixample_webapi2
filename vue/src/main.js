// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from "vue";
import Vuex from "vuex";
import VueRouter from "vue-router";
import App from "./App";

// router setup
import routes from "./routes/routes";

// Plugins
import GlobalComponents from "./globalComponents";
import GlobalDirectives from "./globalDirectives";
import Notifications from "./components/NotificationPlugin";

// MaterialDashboard plugin
import MaterialDashboard from "./material-dashboard";

import Chartist from "chartist";

const axios = require('axios');

// configure router
const router = new VueRouter({
  routes, // short for routes: routes
  linkExactActiveClass: "nav-item active"
});


Vue.prototype.$Chartist = Chartist;

Vue.use(VueRouter);
Vue.use(MaterialDashboard);
Vue.use(GlobalComponents);
Vue.use(GlobalDirectives);
Vue.use(Notifications);
Vue.use(Vuex);


axios.get('http://localhost:8080/api/Session/GetCurrentLoginDetails', {
  headers: {
    Authorization: "Bearer " + localStorage.getItem("token")
  }
})
  .then(function (response) {
    /* eslint-disable no-new */
    new Vue({
      el: "#app",
      render: h => h(App),
      router,
      data: {
        Chartist: Chartist,
        user: response.data.user,
        tenant: response.data.tenant
      }
    });
  });

