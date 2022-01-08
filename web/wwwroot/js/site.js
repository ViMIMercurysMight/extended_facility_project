// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
import { VueAppConfig } from "./components/App";
import store from "./store";

import Vue from "vue"
import Vuex from "vuex";



Vue.use(Vuex);

window.onload = _ => new Vue({
    ...VueAppConfig,
    store : store,

    } );
