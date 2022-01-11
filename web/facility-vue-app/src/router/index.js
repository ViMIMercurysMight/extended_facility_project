import { createRouter, createWebHashHistory } from 'vue-router';
import Home from '../views/Home.vue';
import Facility from "../views/Facility.vue";
import Patient from "../views/Patient.vue";
const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/facility',
        name: 'Facility',
        component: Facility
    },
    {
        path: '/patient',
        name: 'Patient',
        component: Patient
    },
    {
        path: '/about',
        name: 'About',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
    }
];
const router = createRouter({
    history: createWebHashHistory(),
    routes
});
export default router;
//# sourceMappingURL=index.js.map