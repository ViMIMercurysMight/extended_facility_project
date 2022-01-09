
<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <p>
            For a guide and recipes on how to configure / customize this project,<br>
            check out the
            <a href="https://cli.vuejs.org" target="_blank" rel="noopener">vue-cli documentation</a>.
        </p>
        <h3>Installed CLI Plugins</h3>
        <ul>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-babel" target="_blank" rel="noopener">babel</a></li>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-router" target="_blank" rel="noopener">router</a></li>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-vuex" target="_blank" rel="noopener">vuex</a></li>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-eslint" target="_blank" rel="noopener">eslint</a></li>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-unit-mocha" target="_blank" rel="noopener">unit-mocha</a></li>
            <li><a href="https://github.com/vuejs/vue-cli/tree/dev/packages/%40vue/cli-plugin-typescript" target="_blank" rel="noopener">typescript</a></li>
        </ul>
        <h3>Essential Links</h3>
        <ul>
            <li><a href="https://vuejs.org" target="_blank" rel="noopener">Core Docs</a></li>
            <li><a href="https://forum.vuejs.org" target="_blank" rel="noopener">Forum</a></li>
            <li><a href="https://chat.vuejs.org" target="_blank" rel="noopener">Community Chat</a></li>
            <li><a href="https://twitter.com/vuejs" target="_blank" rel="noopener">Twitter</a></li>
            <li><a href="https://news.vuejs.org" target="_blank" rel="noopener">News</a></li>
        </ul>
        <h3>Ecosystem</h3>
        <ul>
            <li><a href="https://router.vuejs.org" target="_blank" rel="noopener">vue-router</a></li>
            <li><a href="https://vuex.vuejs.org" target="_blank" rel="noopener">vuex</a></li>
            <li><a href="https://github.com/vuejs/vue-devtools#vue-devtools" target="_blank" rel="noopener">vue-devtools</a></li>
            <li><a href="https://vue-loader.vuejs.org" target="_blank" rel="noopener">vue-loader</a></li>
            <li><a href="https://github.com/vuejs/awesome-vue" target="_blank" rel="noopener">awesome-vue</a></li>
        </ul>
    </div>
</template>




<script lang="ts">
    import { defineComponent } from 'vue';

  //  import Pagination  from "@/components/common/Pagination.vue"
  //  import FacilityRoot from "@/components/facility/FacilityRootComponent.vue";
  //  import PatientRoot from "@/components/patient/PatientRootComponent.vue";



    export default defineComponent({
        name: 'FacilityRoot',
        props: {
            msg: String,
        },

        el: '#app',

        components: {
     //       "pagination": Pagination,
     //       "facility": FacilityRoot,
     //       "patient": PatientRoot,
        },

        data() {
          return  {
                pageCount: 0,
                pageItems: [],
                statusesList: [],
                isUpdateNow: false,
                updateItem: { },
                isCreateNow: false,
                currentPage: 0,
                }
        },

        mounted: function () {

            // 1--GetCountOfPage
            // 2--GetPageItemJson
            // 3--GetFacilityStatusesJson

        },

        methods: {

            updatePageCount: function () {
                // 1-- GetCountOfPage

            },

            changePage: function (page : number) {

            //    this.currentPage = page;

                // 1-- GetPageItemJson { params page: currentPage }

            },

            remove: function (id : number) {
                // 1-- Delete { params id : id }
            },


            update: function (updatedItem : any) {
                // 1-- Update data : { ....updatedItem }


             //   this.isUpdateNow = false;

            },


            showCreateForm: function () {
           //     this.isCreateNow = true;
            },


            showUpdateForm: function (updateItem : any) {
           //     this.updateItem = updateItem;
          //      this.isUpdateNow = true;
            },


            create: function (data : any) {
            //    this.isCreateNow = false;



            }

    }


    });
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
