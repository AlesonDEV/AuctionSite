'use client';

import Button, {ButtonSlotsAndSlotProps, ButtonTypeMap} from "@mui/joy/Button";
import {redirect, useRouter} from 'next/navigation'


interface IButtonLink {
    href: string,
    children: React.ReactNode,
    size?: ButtonTypeMap['props']['size']
    color?: ButtonTypeMap['props']['color']
    variant?: ButtonTypeMap['props']['variant']
    // [key: keyof ButtonTypeMap['props']]: any
}

const ButtonLink: React.FC<IButtonLink> = (props) => {
    const router = useRouter()

    return (
        <Button
            variant={'solid'}
            color={'success'}
            onClick={() => {
                router.push(props.href)
            }}
            size={props.size}

        >
            {props.children}
        </Button>
    )
}

export default ButtonLink