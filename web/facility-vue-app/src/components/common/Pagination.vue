<template>
    <nav aria-label="...">
        <ul class='pagination pagination-sm'>
            <li class="page-item ">
                <a class='page-link'
                   v-on:click.prevent='changePageCallback( 0 )'
                   href=''> 1 </a>
            </li>

            <li 
                v-bind:key = "i"    
                 v-for= 'i in this.$store.state.pageCount'
                class="page-item ">
                <a class='page-link'
                v-on:click.prevent = 'changePageCallback( i )'
                href = '' >
                {{ i+1 }}
                </a>
            </li>

            <li>
                &nbsp;&nbsp;&nbsp; {{pageRow}}
            </li>
        </ul>
    </nav>



</template>

 

<script lang="ts">
    import { defineComponent } from 'vue';


    export default defineComponent({
        name: "pagination",
        props: ['changePageCallback'],


        computed: {
            pageRow: function () {
                return  ((this.$store.state.currentPage * this.$store.state.perPage) + this.$store.state.perPage) + " / " + this.$store.state.totalRecords;
            }
        }


    });


</script>
