import {UPDATE_USER,AUTH_USER} from '../actions/user-actions'

export function userReducer(state = '', { type, payload }) {
    switch (type) {

        case UPDATE_USER:
            return payload.user;

        // case AUTH_USER:
        //     return payload.authed;

        default:
            return state;
    }
}

export function authReducer(state = false, { type, payload }) {
    
    switch (type) {
        case AUTH_USER:
            return payload.authed;

        default:
            return state;
    }
}
