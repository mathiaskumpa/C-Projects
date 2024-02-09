<script setup>
import { reactive, ref } from "vue";
import axios from 'axios'

const error = ref('')
const form = reactive({
    UserName: null,
    Password: null
})

async function login() {
    try {
        const response = await axios.post('http://localhost:3000/api/users/login', form)
        console.log(response.data)
    } catch (e) {
        if (e.response.status == 400) {
            error.value = 'Login failed'
        }
    }
}
</script>
<template>
    <form @submit.prevent="login()">
        <div class="p-6 bg-red-100 text-red-700" v-if="error">
            {{ error }}
        </div>
        <div class="flex flex-col">
            <label for="username">Username</label>
            <input type="text" id="username" required v-model="form.UserNamesername" placeholder="Username" class="border p-3" />
        </div>
        <div class="flex flex-col">
            <label for="password">Password</label>
            <input type="password" id="password" required v-model="form.Password" placeholder="Password" class="border p-3" />
        </div>

        <div class="flex flex-col justify-center mt-3">
            <button type="submit" class="border w-[100px] mx-auto p-2">Login</button>
        </div>
    </form>
</template>