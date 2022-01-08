// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
import { VueAppConfig } from "./components/App";
import Vue from "vue"

window.onload = _ => new Vue(VueAppConfig);
