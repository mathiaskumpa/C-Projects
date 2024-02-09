<script setup>
import { onMounted, reactive } from "vue";
import axios from 'axios'

axios.defaults.baseURL = 'http://localhost:5232'
axios.defaults.headers.common['Access-Allow-Origin'] = ['*']
axios.defaults.headers.common['Access-Allow-Methods'] = ['POST', 'GET']

const form = reactive({
    username: null,
    password: null
})

async function login() {
    const response = await axios.post('http://localhost:5232/api/users/login', form, {
        withCredentials: true
    })
    console.log(response.data)
}

onMounted(() => {
    axios.get('http://localhost:5232/api/users').then(data => {
        console.log(data)
    }).catch(e => console.error(e))
})
</script>
<template>
    <form @submit.prevent="login()">
        <div class="flex flex-col">
            <label for="username">Username</label>
            <input type="text" id="username" required v-model="form.username" placeholder="Username" class="border p-3" />
        </div>
        <div class="flex flex-col">
            <label for="password">Password</label>
            <input type="text" id="password" required v-model="form.password" placeholder="Password" class="border p-3" />
        </div>

        <div class="flex flex-col justify-center mt-3">
            <button type="submit" class="border w-[100px] mx-auto p-2">Login</button>
        </div>
    </form>
</template>