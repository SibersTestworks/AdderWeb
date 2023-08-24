<template>
    <div class="container mt-5">
        <h1 class="mb-4">Калькулятор</h1>
        <div class="mb-3">
            <input v-model="num1" type="number" class="form-control" placeholder="Первое число">
            <input v-model="num2" type="number" class="form-control mt-2" placeholder="Второе число">
        </div>
        <button @click="sumNumbers" class="btn btn-primary">Сложить</button>
        <div class="mt-3">
            <strong>Результат: {{ result }}</strong>
        </div>
    </div>
</template>

<!--<script>
    import { defineComponent } from 'vue';
    export default {
        data() {
            return {
                num1: 0,
                num2: 0,
                result: 0
            };
        },
        methods: {
            async sumNumbers() {
                const response = await fetch('Sum', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        num1: this.num1,
                        num2: this.num2
                    })
                });
                const data = await response.json();
                this.result = data.result;
            }
        }
    };
</script>-->
