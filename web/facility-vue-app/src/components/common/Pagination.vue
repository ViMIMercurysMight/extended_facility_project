<template>
    <ul class='nav'>
        <a class='nav-link'
           onclick="return false;"
           v-on:click='changePageCallback( 0 )'
           href=''> 0 </a>
        <a class='nav-link'
           v-for='i in pageCount'
           onclick="return false;"
           v-bind:key="i"
           v-on:click='changePageCallback( i )'
           href=''>
            {{i}}
        </a>
    </ul>
</template>


<script lang="ts">
    import { defineComponent } from 'vue';

    export default defineComponent({
        name : "pagination",
        props: ["pageCount", 'changePageCallback'],
    });

</script>
