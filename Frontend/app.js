const routes=[
    {path:'/home',component:home},
    {path:'/student',component:student},
    {path:'/course',component:course},
    {path:'/department',component:department}
]

const router=new VueRouter({
    routes
})

const app = new Vue({
    router
}).$mount('#app')