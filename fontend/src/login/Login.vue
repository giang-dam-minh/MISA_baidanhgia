<template>
    <div>
        <div class="page-login">
            <div class="box-login">
                <div class="title-login">
                    Sign in
                </div>
                <form action="">
                    <div class="line-input">
                        <label for="" class="label-input">Email</label>
                        <cc-input :placeholderInput="placeholderUsername" />
                    </div>
                    <div class="line-input">
                        <label for="" class="label-input">Password</label>
                        <cc-input :placeholderInput="placeholderPassword" />
                    </div>
                    <div class="line-tool">
                        <div class="item-tool">Forgot password</div>
                        <div class="item-tool">Sign up</div>
                    </div>
                    <div class="line-submit">
                        <cc-button>Sign in</cc-button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>
<script>
import CcButton from '../components/button/ccButton.vue'
import ccInput from '../components/input/ccInput.vue'
export default {
    components: { ccInput },
    data() {
        CcButton
        return {
            placeholderUsername:"Enter your username",
            placeholderPassword: "Enter your password"
        }
    }
}
</script>
<style lang="scss" scoped>
.page-login {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100vw;
    height: 100vh;
    background-color: #ffffff;
}
    .box-login {
        display: flex;
        flex-direction: column;
        width: 33%;
    }
        .title-login {
            width: 100%;
            text-align: center;
            font-weight: 700;
            font-size: 3rem/* 48px */;
            line-height: 1;
            --tw-text-opacity: 1;
            color: rgba(16, 185, 129, var(--tw-text-opacity));
            margin-bottom: 3.5rem/* 56px */;
        }
        .line-input {
            display: flex;
            margin-top: 1.25rem/* 20px */;
            margin-bottom: 1.25rem/* 20px */;
            flex-direction: column;
        }
        .line-tool {
            display: flex;
            flex-direction: row;
            justify-content: space-between;
            margin-top: 0.5rem/* 8px */;
            margin-bottom: 0.5rem/* 8px */;
        }
            .label-input {
                margin-bottom: 10px;
            } 
            .item-tool {
                text-decoration: underline;
                font-style: italic;
                cursor: pointer;
            }
        .line-submit {
            display: flex;
            margin-top: 2.5rem/* 40px */;
            margin-bottom: 2.5rem/* 40px */;
            justify-content: center;
        }
</style>