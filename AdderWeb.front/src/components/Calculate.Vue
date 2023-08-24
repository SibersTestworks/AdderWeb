<template>
    <div class="container d-flex justify-content-center align-items-center vh-100">
        <div class="card p-4">
            <h1 class="mb-4">Adder</h1>
            <div class="mb-3 d-flex">
                <input v-model="first" type="number" class="form-control me-2" placeholder="First numer">
                <input v-model="second" type="number" class="form-control" placeholder="Second number">
            </div>
            <button @click="SumNumbers" class="btn btn-primary" :disabled="isCalculating">Sum</button>
            <div class="mt-3">
                <strong>Result: {{ result }}</strong>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                first: null,
                second: null,
                result: 0,
                isCalculating: false
            };
        },
        methods: {
            SumNumbers() {
                try {
                    this.isCalculating = true;
                    let response = fetch("Sum/add", {
                        method: "POST",
                        headers: { "Accept": "application/json", "Content-Type": "application/json" },
                        body: JSON.stringify({
                            first: this.first,
                            second: this.second
                        })
                    })
                        .then((response) => response.json())
                        .then((data) => {
                            this.first = data.first,
                                this.second = data.second,
                                this.result = data.result
                        });
                } catch (e) {
                    console.log(e);
                }
                finally { this.isCalculating = false; }
            }
        }
    };
</script>
